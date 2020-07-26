var DOMType;
(function (DOMType) {
    DOMType[DOMType["Text"] = 0] = "Text";
    DOMType[DOMType["Markup"] = 1] = "Markup";
    DOMType[DOMType["Element"] = 2] = "Element";
    DOMType[DOMType["Marker"] = 3] = "Marker";
    DOMType[DOMType["Event"] = 4] = "Event";
    DOMType[DOMType["Remove"] = 5] = "Remove";
})(DOMType || (DOMType = {}));
var WebViewRenderer = /** @class */ (function () {
    function WebViewRenderer() {
        this.mapping = {};
        this.firstReceived = true;
    }
    WebViewRenderer.prototype.getValues = function (dictionary) {
        var keys = Object.getOwnPropertyNames(dictionary);
        return keys.map(function (k) { return dictionary[k]; });
    };
    WebViewRenderer.prototype.parseMarkup = function (markup) {
        var parser = new DOMParser();
        var dom = parser.parseFromString(markup, "text/html");
        if (!dom) {
            var doc = document.implementation.createHTMLDocument("");
            if (markup.toLowerCase().indexOf('<!doctype') > -1) {
                doc.documentElement.innerHTML = markup;
            }
            else {
                doc.body.innerHTML = markup;
            }
            dom = doc;
        }
        var nodes = [];
        if (dom) {
            for (var i = 0; i < dom.body.childNodes.length; i++) {
                nodes.push(dom.body.childNodes.item(i));
            }
        }
        return nodes;
    };
    WebViewRenderer.prototype.render = function (model) {
        var _this = this;
        this.mapping[model.id] = model;
        switch (model.type) {
            default: {
                var textModel = model;
                var node = document.createTextNode(textModel.text);
                model.nodes = [node];
                return model.nodes;
            }
            case DOMType.Markup: {
                var markupModel = model;
                model.nodes = this.parseMarkup(markupModel.markup);
                return model.nodes;
            }
            case DOMType.Element: {
                var elementModel = model;
                var dom = document.createElement(elementModel.tag);
                for (var _i = 0, _a = Object.getOwnPropertyNames(elementModel.attributes); _i < _a.length; _i++) {
                    var key = _a[_i];
                    var value = elementModel.attributes[key];
                    dom.setAttribute(key, value);
                }
                var _loop_1 = function (key) {
                    var event_1 = elementModel.events[key];
                    dom.addEventListener(key.replace("on", ""), function (arg) {
                        var param = {};
                        for (var _i = 0, _a = Object.getOwnPropertyNames(arg); _i < _a.length; _i++) {
                            var key_1 = _a[_i];
                            var value = arg[key_1];
                            var type = typeof value;
                            if (type === "number" || type === "string" || type === "boolean") {
                                param[key_1] = value;
                            }
                        }
                        window.location.href = window.location.protocol + "//__event__?" + "id=" + event_1.id + "&v=" + encodeURI(JSON.stringify(param));
                    });
                };
                for (var _b = 0, _c = Object.getOwnPropertyNames(elementModel.events); _b < _c.length; _b++) {
                    var key = _c[_b];
                    _loop_1(key);
                }
                var sortedChildren = this.getValues(elementModel.children).sort(function (a, b) {
                    return a.sequenceNumber - b.sequenceNumber;
                });
                for (var _d = 0, sortedChildren_1 = sortedChildren; _d < sortedChildren_1.length; _d++) {
                    var child = sortedChildren_1[_d];
                    var childNodes = this.render(child);
                    for (var _e = 0, childNodes_1 = childNodes; _e < childNodes_1.length; _e++) {
                        var node = childNodes_1[_e];
                        dom.appendChild(node);
                    }
                }
                //for (const key of Object.getOwnPropertyNames(elementModel.children)) {
                //    const childNodes = this.render(elementModel.children[key]);
                //    for (const node of childNodes) {
                //        dom.appendChild(node);
                //    }
                //}
                model.nodes = [dom];
                return model.nodes;
            }
            case DOMType.Marker: {
                var markerModel_1 = model;
                var keys = Object.getOwnPropertyNames(markerModel_1.children);
                model.nodes = [];
                var opening = document.createComment("Start " + (markerModel_1.tag || ""));
                model.nodes.push(opening);
                var nds = keys.map(function (c) { return _this.render(markerModel_1.children[c]); });
                nds.reduce(function (prev, cur, i, nds) {
                    for (var _i = 0, cur_1 = cur; _i < cur_1.length; _i++) {
                        var c = cur_1[_i];
                        model.nodes.push(c);
                    }
                    return model.nodes;
                }, model.nodes);
                var closing = document.createComment("End " + (markerModel_1.tag || ""));
                model.nodes.push(closing);
                return model.nodes;
            }
        }
    };
    WebViewRenderer.prototype.removeRecursive = function (model) {
        delete this.mapping[model.id];
        var parent = this.mapping[model.parentId];
        if (parent) {
            var parentElementModel = parent;
            delete parentElementModel.children[model.id];
        }
        model.nodes.forEach(function (n) { return n.parentNode.removeChild(n); });
        if (model.type === DOMType.Element || model.type === DOMType.Marker) {
            var elementModel = model;
            for (var _i = 0, _a = Object.getOwnPropertyNames(elementModel.children); _i < _a.length; _i++) {
                var key = _a[_i];
                this.removeRecursive(elementModel.children[key]);
            }
        }
    };
    WebViewRenderer.prototype.patch = function (newModel) {
        var _a;
        var existingModel = this.mapping[newModel.id];
        if (newModel.type === DOMType.Remove) {
            this.removeRecursive(existingModel);
        }
        else if (!existingModel) {
            var newNodes = this.render(newModel);
            var parent_1 = this.mapping[newModel.parentId];
            var parentNode_1 = parent_1.nodes[0];
            var reference_1 = null;
            this.getValues(parent_1.children).some(function (c) {
                if (c.sequenceNumber > newModel.sequenceNumber) {
                    reference_1 = c;
                    return true;
                }
                return false;
            });
            var referenceNode_1 = (_a = reference_1) === null || _a === void 0 ? void 0 : _a.nodes[0];
            newNodes.forEach(function (node) { return parentNode_1.insertBefore(node, referenceNode_1); });
            parent_1.children[newModel.id] = newModel;
        }
        else {
            switch (existingModel.type) {
                default: {
                    var textModel = newModel;
                    var newNode = document.createTextNode(textModel.text);
                    existingModel.nodes[0].parentNode.replaceChild(newNode, existingModel.nodes[0]);
                    existingModel.nodes = [newNode];
                    break;
                }
                case DOMType.Markup: { //ideally, markup whould never change once rendered
                    var markupModel = newModel;
                    var nodes = this.parseMarkup(markupModel.markup);
                    var parent_2 = existingModel.nodes[0].parentNode;
                    var referenceNode_2 = null;
                    existingModel.nodes.forEach(function (node) {
                        referenceNode_2 = node.nextSibling;
                        parent_2.removeChild(node);
                    });
                    existingModel.nodes = [];
                    nodes.forEach(function (node, key, _parent) {
                        parent_2.insertBefore(node, referenceNode_2);
                        existingModel.nodes.push(node);
                    });
                    break;
                }
                case DOMType.Element: {
                    var elementModel = newModel;
                    var element = elementModel.nodes[0];
                    var newAttributeKeys_2 = Object.getOwnPropertyNames(elementModel.attributes);
                    for (var _i = 0, newAttributeKeys_1 = newAttributeKeys_2; _i < newAttributeKeys_1.length; _i++) {
                        var key = newAttributeKeys_1[_i];
                        element.setAttribute(key, elementModel.attributes[key]);
                    }
                    var oldAttributeKeys = Object.getOwnPropertyNames(existingModel.attributes);
                    var removedAttributes = oldAttributeKeys.filter(function (oldKey) { return !newAttributeKeys_2.some(function (newKey) { return newKey === oldKey; }); });
                    for (var _b = 0, removedAttributes_1 = removedAttributes; _b < removedAttributes_1.length; _b++) {
                        var key = removedAttributes_1[_b];
                        element.attributes.removeNamedItem(key);
                    }
                    break;
                }
            }
        }
    };
    WebViewRenderer.prototype.update = function (models) {
        if (this.firstReceived) {
            var html = this.render(models[0])[1]; //TODO: auto detect index 1
            var n = 0;
            while (document.head.childNodes.length > n) {
                var item = document.head.childNodes.item(n);
                if (!(item instanceof Element) || !item.hasAttribute("static"))
                    item.remove();
                else
                    n++;
            }
            n = 0;
            while (document.body.childNodes.length > n) {
                var item = document.body.childNodes.item(n);
                if (!(item instanceof Element) || !item.hasAttribute("static"))
                    item.remove();
                else
                    n++;
            }
            while (html.childNodes[1].childNodes.length > 0) { //TODO: auto detect index 1
                document.head.appendChild(html.childNodes[1].childNodes.item(0));
            }
            while (html.childNodes[3].childNodes.length > 0) { //TODO: auto detect index 3
                document.body.appendChild(html.childNodes[3].childNodes.item(0));
            }
            this.firstReceived = false;
        }
        else {
            for (var _i = 0, models_1 = models; _i < models_1.length; _i++) {
                var model = models_1[_i];
                this.patch(model);
            }
        }
    };
    return WebViewRenderer;
}());
window["webView"] = new WebViewRenderer();
//# sourceMappingURL=WebView.js.map