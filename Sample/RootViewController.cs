﻿using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Sample
{
	public partial class RootViewController : UIViewController
	{
		// the sidebar controller for the app
		public XamarinSidebar.SidebarController SidebarController { get; private set; }

		public RootViewController() : base(null, null)
		{
			// create a slideout navigation controller with the top navigation controller and the menu view controller
			SidebarController = new XamarinSidebar.SidebarController(new ContentController(), new SideMenuController());
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// set the view to the sidebar controller
			SidebarController.View.Frame = UIScreen.MainScreen.Bounds;
			// handle wiring things up so events propogate properly
			AddChildViewController(SidebarController);
			View.AddSubview(SidebarController.View);
			SidebarController.DidMoveToParentViewController(this);
		}
	}
}

