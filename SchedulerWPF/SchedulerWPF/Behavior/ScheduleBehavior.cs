using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace SchedulerWPF
{
    public class ScheduleBehavior : Behavior<Grid>
    {
        Grid grid;
        SfScheduler schedule;
        protected override void OnAttached()
        {
            grid = this.AssociatedObject as Grid;
            schedule = grid.Children[0] as SfScheduler;
            schedule.AppointmentDropping += Schedule_AppointmentDropping;
        }

private void Schedule_AppointmentDropping(object sender, AppointmentDroppingEventArgs e)
{
    if (e.SourceResource != e.TargetResource)
    {
        e.Cancel = true;
        MessageBox.Show("You have trying to dropped to another resource, please drop within the resource");
    }
}

        protected override void OnDetaching()
        {
            base.OnDetaching();
            grid = null;
            schedule = null;
            schedule.AppointmentDropping -= Schedule_AppointmentDropping;
        }
       
    }
}
