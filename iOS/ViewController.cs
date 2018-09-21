using System;

using UIKit;

namespace NotesApp.iOS
{
    public partial class ViewController : UIViewController
    {
        public string[] list = {"A", "B", "C", "D"};
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            notesTableView.Source = new NotesTableViewSource(list);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
