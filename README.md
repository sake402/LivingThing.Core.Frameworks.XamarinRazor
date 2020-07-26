# LivingThing.Core.Frameworks.XamarinRazor
Why XamarinRazor?
---
1. Because we love Xamarin
2. I find Xaml syntax too awkward (this is personal)
3. But razor syntax is just great
4. What about Microsoft MobileBlazorBinding. Yes I know it exist. 
	4.1. But it is still a pain to generate a custom component with it. I mean you have to write two classes, (one a component with setter and getters and the other its handler) and then start mapping properties from the Component to the Xamarin.Forms element from within the handler. I prefer not to write any code to add a new component (lazy me). So [here](https://github.com/sake402/LivingThing.Tools.XamarinRazor) is a tool that simply generate the components from an assembly. We also have a DefaultNativeElementAdapter that arrange the hierachy of any Xamarin elements based on the razor syntax. You can also roll out your own IElementAdapter and register into the DI container.

So how do we use it?
---
I thought you'd never ask.
1. Install the [Nuget Package](https://www.nuget.org/packages/LivingThing.Core.Frameworks.XamarinRazor/1.0.0)
2. At your application startup call 
```C#
 var serviceProvider = XamarinRazor.XamarinRazor.Initialize((services)=>{
	//register any other service your application need here
 });
 ```
 or if you already have a ServiceCollection
 ```C#
 services.UseXamarinRazor();
```

Now you can author a page in Razor like


*_Imports.razor*
```
@using XF=Xamarin.Forms
@using LivingThing.Core.Frameworks.XamarinRazor
@using LivingThing.Core.Frameworks.XamarinRazor.Forms
```

*Counter.razor*
```
<StyleSheet Resource="style.css" Assembly="GetType().Assembly" />

<TabbedPage>
    <ContentPage Title="Page 1">
        <Test></Test>
        <Label TextColor="XF.Color.Purple">Hello @count</Label>
        <Button OnCommand="()=> count++">OK</Button>
    </ContentPage>
    @if (count < 2)
    {
        <ContentPage Title="@("Page" +  count)">
            <Label Text="Hello 2"></Label>
        </ContentPage>
    }
    @if (count > 5)
    {
        <ContentPage Title="Page 3">
            <Label Text="Hello 3"></Label>
        </ContentPage>
    }
</TabbedPage>
@code{
	int count;;
}
```

*Test.razor*
```
<StackLayout Orientation="XF.StackOrientation.Horizontal">
	<Frame CornerRadius="10">
		Hello @(count+1)
		@if (count < 2)
		{
			<Label Text="@("Hello " + count.ToString())" TextColor="XF.Color.Green"></Label>
		}
		@if (count > 5)
		{
			<Label Text="@("Hello " + count.ToString())" TextColor="XF.Color.Red"></Label>
		}
		<Label TextColor="XF.Color.Purple">Hello @count</Label>
		<Button OnCommand="()=> count++">OK</Button>
	</Frame>
</StackLayout>
@code{
	int count;;
}
```

*Code*
```C#
var page = Razor.Create<Counter, TabbedPage>(ServiceProvider).Result;
Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(page);
```
or
```c#
var view = Razor.Create<Counter, ContentView>(ServiceProvider).Result;
 ```
 
Is it buggy?
---
Sure it is. We love bugs when they are reported(who doesn't), just so we can squash them.
We promise to fix every reported bugs in no time. 

Who is using this?
---
Just us for now. We currently use this in all our cross platform mobile application developement.

Third party library support
---
So you have a third party library to use in razor? [Run LivingThing.Tools.XamarinRazor](https://github.com/sake402/LivingThing.Tools.XamarinRazor)
```
LivingThing.Tools.XamarinRazor --assembly PathToMyThirdPartyAssembly --output PathToPlaceGeneratedFiles
```
Now you can use the third party library in razor as
```
<MyThirdPartyComponent MyParameter="Foo"/>
```

What about Live Reloading
---
Working on it. We currently have a [LivingThing.LiveBlazor](https://github.com/sake402/LivingThing.LiveBlazor) that enable live razor editting in Server Side blazor application. We are adding support for xamarin project to this.
