# LayersCMS #
## ASP.Net Content Management System using MVC4 ##

LayersCMS is a C#-based ASP.Net MVC4 content management system designed to allow developers to pick up and use with a small learning curve.

It's still in development, and is very basic at the moment. The project stemmed from frustration with other ASP.Net open source CMS solutions, that offer more than is often necessary and aren't alway easy to extend when you need to implement some custom functionality. LayersCMS aims to eradicate these difficulties by keeping the code clean and simple and limiting layers of abstraction, allowing anybody who knows ASP.Net MVC to deploy and extend with relative ease.

### Made with great open source software ###

There's so much great open source software out there, you'd be a fool to not use it and participate in the communities. Amongst others, QuickWin uses Asp.NET MVC4, MvcMailer, Twitter Bootstrap (minimal use for form styling and buttons) and Attribute Routing.

[MvcMailer](https://github.com/smsohan/MvcMailer) is used to power email notifications from the contact forms.

[Twitter Bootstrap](http://twitter.github.com/bootstrap/) is used for some basic styling, mainly for the contact form.

[Attribute Routing](https://github.com/mccalltd/AttributeRouting/wiki) is used to make it easier to define routes within your controller, no need to faff about with the global.asax to define your routes (unless you really want to!).

#### Keeping things simple ####
We could make use of the Bootstrap grid system for the layout, but that's an extra piece of learning for you to do if you're unfamiliar with it. So the CSS is all hand crafted, no [LESS](http://lesscss.org/) or [SASS](http://sass-lang.com/), just plain ol' CSS - again, less to learn, easier for you to pick up for a "quick win". If you want to take it on and add some form of dynamic CSS, be my guest!


#####*It's all very simple, but that's the point!*#####
