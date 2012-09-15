# QuickWin MVC4 #

QuickWin is a C# MVC4 simple website template, no content management system, no database, no dependency resolution (there's no real need for it, yet!). It's simple, it'll get you up and running with a basic website with a standard theme, and will let you utilise the power of .NET and MVC4 to quickly build a static website.

If you want to take it from there and build on top of it, you can. It's only meant as a base. Nothing that has been done so far should stop you progressing and added features. Sure, you might want to add some dependency resolution, some caching, some dynamic stuff, but that's up to you. Or, you can use it to just create a simple site.

## Made with great open source software ##

There's so much great open source software out there, you'd be a fool to not use it and participate in the communities. Amongst others, QuickWin uses Asp.NET MVC4, MvcMailer, Twitter Bootstrap (minimal use for form styling and buttons) and Attribute Routing.

[MvcMailer](https://github.com/smsohan/MvcMailer) is used to power email notifications from the contact forms.

[Twitter Bootstrap](http://twitter.github.com/bootstrap/) is used for some basic styling, mainly for the contact form.

[Attribute Routing](https://github.com/mccalltd/AttributeRouting/wiki) is used to make it easier to define routes within your controller.

## Keeping things simple ##
We could make use of the Bootstrap grid system for the layout, but that's an extra piece of learning for you to do if you're unfamiliar with it. So the CSS is all hand crafted, no [LESS](http://lesscss.org/) or [SASS](http://sass-lang.com/), just plain ol' CSS - again, less to learn, easier for you to pick up for a "quick win". If you want to take it on and add some form of dynamic CSS, be my guest!

## Adding actions ##

With attribute routing, it's very easy to add another action to represent a frontend web page.

Add an ActionResult method to an existing Controller, or create a new Controller and add the method to that.
Not the `[GET("/")]` attribute, that defines that the action should be run for all HTTP GET requests for the URL '/my-first-page'

`[GET("my-first-page")] public ActionResult MyFirstPage() { return View(); }`

Once you've got your action ready, add the view file (currently using the Razor view engine that ships with MVC3 and MVC4)


*It's all very simple, but that's the point!*
