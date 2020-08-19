enum DOMType{
    Text,
    Markup,
    Element,
    Marker,
    Event,
    Remove
}
interface DOMEvent {
    id: number;
    name: string;
}
interface DOMModel {
    id: number;
    parentId: number;
    sequenceNumber: number;
    type: DOMType;
    nodes: Node[];
}
interface DOMTextModel extends DOMModel {
    text: string;
}
interface DOMMarkupModel extends DOMModel {
    markup: string;
}
interface DOMElementModel extends DOMModel{
    tag: string;
    events: { [key: string]: DOMEvent };
    attributes: { [key: string]: any };
    children: { [key: number]: DOMModel };
}

class WebViewRenderer {
    mapping: { [key: number]: DOMModel } = {};
    getValues<T>(dictionary: { [key: string]: T }): T[] {
        const keys = Object.getOwnPropertyNames(dictionary);
        return keys.map(k => dictionary[k]);
    }
    parseMarkup(markup: string): Node[] {
        const parser = new DOMParser();
        let dom = parser.parseFromString(markup, "text/html");
        if (!dom) {
            const doc = document.implementation.createHTMLDocument("");
            if (markup.toLowerCase().indexOf('<!doctype') > -1) {
                doc.documentElement.innerHTML = markup;
            }
            else {
                doc.body.innerHTML = markup;
            }
            dom = doc;
        }
        const nodes: Node[] = [];
        if (dom) {
            for (let i = 0; i < dom.body.childNodes.length; i++) {
                nodes.push(dom.body.childNodes.item(i));
            }
        }
        return nodes;
    }
    getPhysicalParent(model: DOMModel): DOMElementModel {
        const parent = this.mapping[model.parentId];
        if (parent.type == DOMType.Marker) {
            return this.getPhysicalParent(parent);
        }
        return parent as DOMElementModel;
    }
    render(model: DOMModel): Node[] {
        this.mapping[model.id] = model;
        switch (model.type) {
            default: {
                const textModel: DOMTextModel = model as DOMTextModel;
                const node = document.createTextNode(textModel.text);
                model.nodes = [node];
                return model.nodes;
            }
            case DOMType.Markup: {
                const markupModel: DOMMarkupModel = model as DOMMarkupModel;
                model.nodes = this.parseMarkup(markupModel.markup);
                return model.nodes;
            }
            case DOMType.Element: {
                const elementModel: DOMElementModel = model as DOMElementModel;
                const dom = document.createElement(elementModel.tag);
                if (elementModel.attributes) {
                    for (const key of Object.getOwnPropertyNames(elementModel.attributes)) {
                        const value = elementModel.attributes[key];
                        dom.setAttribute(key, value);
                    }
                }
                if (elementModel.events) {
                    for (const key of Object.getOwnPropertyNames(elementModel.events)) {
                        const event = elementModel.events[key];
                        dom.addEventListener(key.replace("on", ""), (arg) => {
                            const param: any = {};
                            for (const key of Object.getOwnPropertyNames(arg)) {
                                const value = arg[key];
                                const type = typeof value;
                                if (type === "number" || type === "string" || type === "boolean") {
                                    param[key] = value;
                                }
                            }
                            window.location.href = window.location.protocol + "//__event__?" + "id=" + event.id + "&v=" + encodeURI(JSON.stringify(param));
                        });
                    }
                }
                if (elementModel.children) {
                    const sortedChildren = this.getValues(elementModel.children).sort((a, b) => {
                        return a.sequenceNumber - b.sequenceNumber;
                    });
                    for (const child of sortedChildren) {
                        const childNodes = this.render(child);
                        for (const node of childNodes) {
                            dom.appendChild(node);
                        }
                    }
                    //for (const key of Object.getOwnPropertyNames(elementModel.children)) {
                    //    const childNodes = this.render(elementModel.children[key]);
                    //    for (const node of childNodes) {
                    //        dom.appendChild(node);
                    //    }
                    //}
                } else
                    elementModel.children = {};
                model.nodes = [dom];
                return model.nodes;
            }
            case DOMType.Marker: {
                const markerModel: DOMElementModel = model as DOMElementModel;
                model.nodes = [];
                const opening = document.createComment(`Start ${markerModel.tag || ""}`);
                model.nodes.push(opening);
                if (markerModel.children) {
                    const keys = Object.getOwnPropertyNames(markerModel.children);
                    const nds = keys.map(c => this.render(markerModel.children[c]));
                    nds.reduce((prev: Node[], cur: Node[], i: number, nds: Node[][]) => {
                        for (const c of cur) {
                            model.nodes.push(c);
                        }
                        return model.nodes;
                    }, model.nodes);
                }
                const closing = document.createComment(`End ${markerModel.tag || ""}`);
                model.nodes.push(closing);
                return model.nodes;
            }
        }
    }
    removeRecursive(model: DOMModel) {
        delete this.mapping[model.id];
        const parent = this.mapping[model.parentId];
        if (parent) {
            const parentElementModel = parent as DOMElementModel;
            delete parentElementModel.children[model.id];
            parentElementModel.nodes = parentElementModel.nodes.filter(n => !model.nodes.some(node => node == n));
        }
        model.nodes.forEach(n => n.parentNode?.removeChild(n));
        if (model.type === DOMType.Element || model.type === DOMType.Marker) {
            const elementModel: DOMElementModel = model as DOMElementModel;
            if (elementModel.children) {
                for (const key of Object.getOwnPropertyNames(elementModel.children)) {
                    this.removeRecursive(elementModel.children[key]);
                }
            }
        }
    }
    patch(newModel: DOMModel) {
        const existingModel = this.mapping[newModel.id];
        if (newModel.type === DOMType.Remove) {
            this.removeRecursive(existingModel);
        } else if (!existingModel) {
            const newNodes = this.render(newModel);
            const parent = this.getPhysicalParent(newModel);// this.mapping[newModel.parentId] as DOMElementModel;
            const parentNode = parent.nodes[0];
            let reference: DOMModel = null;
            if (parent.children) {
                this.getValues(parent.children).some(c => {
                    if (c.sequenceNumber > newModel.sequenceNumber) {
                        reference = c;
                        return true;
                    }
                    return false;
                });
            }
            const referenceNode = reference?.nodes[0];
            newNodes.forEach(node => parentNode.insertBefore(node, referenceNode));
            parent.children[newModel.id] = newModel;
        } else {
            switch (existingModel.type) {
                default: {
                    const textModel: DOMTextModel = newModel as DOMTextModel;
                    const newNode = document.createTextNode(textModel.text);
                    existingModel.nodes[0].parentNode.replaceChild(newNode, existingModel.nodes[0])
                    existingModel.nodes = [newNode];
                    break;
                }
                case DOMType.Markup: { //ideally, markup whould never change once rendered
                    const markupModel: DOMMarkupModel = newModel as DOMMarkupModel;
                    const nodes = this.parseMarkup(markupModel.markup);
                    const parent = existingModel.nodes[0].parentNode;
                    let referenceNode: Node = null;
                    existingModel.nodes.forEach(node => {
                        referenceNode = node.nextSibling;
                        parent.removeChild(node);
                    });
                    existingModel.nodes = [];
                    nodes.forEach((node, key, _parent) => {
                        parent.insertBefore(node, referenceNode);
                        existingModel.nodes.push(node);
                    });
                    break;
                }
                case DOMType.Element: {
                    const elementModel: DOMElementModel = newModel as DOMElementModel;
                    const element = existingModel.nodes[0] as Element;
                    const newAttributeKeys = Object.getOwnPropertyNames(elementModel.attributes);
                    for (const key of newAttributeKeys) {
                        element.setAttribute(key, elementModel.attributes[key]);
                    }
                    const oldAttributeKeys = Object.getOwnPropertyNames((existingModel as DOMElementModel).attributes);
                    const removedAttributes = oldAttributeKeys.filter(oldKey => !newAttributeKeys.some(newKey => newKey === oldKey));
                    for (const key of removedAttributes) {
                        element.attributes.removeNamedItem(key);
                    }
                    break;
                }
            }
        }
    }
    firstReceived = true;
    update(models: DOMModel[], forceFirstUpdate: boolean) {
        if (this.firstReceived || forceFirstUpdate) {
            const html = this.render(models[0])[1];//TODO: auto detect index 1
            let n = 0;
            while (document.head.childNodes.length > n) {
                const item = document.head.childNodes.item(n);
                //if (!(item instanceof Element) || !(item as Element).hasAttribute("static"))
                    item.remove();
                //else
                //    n++;
            }
            n = 0;
            while (document.body.childNodes.length > n) {
                const item = document.body.childNodes.item(n);
                //if (!(item instanceof Element) || !(item as Element).hasAttribute("static"))
                    item.remove();
                //else
                //    n++;
            }
            while (html.childNodes[0].childNodes.length > 0) {//TODO: auto detect index 1
                document.head.appendChild(html.childNodes[0].childNodes.item(0));
            }
            while (html.childNodes[1].childNodes.length > 0) {//TODO: auto detect index 3
                document.body.appendChild(html.childNodes[1].childNodes.item(0));
            }
            this.firstReceived = false;
        } else {
            for (const model of models) {
                this.patch(model);
            }
        }
    }

    execute(fn: string, param: any):any {
        const f = new Function(fn);
        return f.call(this, param);
    }
}

window["webView"] = new WebViewRenderer();