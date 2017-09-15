
using Android.App;
using Android.Content;
using Android.Appwidget;
using Android.Widget;
using System;

namespace AndroidWidgetDemo
{
    [BroadcastReceiver(Label = "HelloAppWidget")]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/appwidgetprovider")]
    public class AppWidget : AppWidgetProvider
    {
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context, appWidgetIds));
        }

        public override void OnReceive(Context context, Intent intent)
        {

        }

        private RemoteViews BuildRemoteViews(Context context, int[] appWidgetIds)
        {
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.widget);

            //SetTextViewText(widgetView);
            //RegisterClicks(context, appWidgetIds, widgetView);

            return widgetView;
        }

        //private void RegisterClicks(Context context, int[] appWidgetIds, RemoteViews widgetView)
        //{
        //    var intent = new Intent(context, typeof(AppWidget));
        //    intent.SetAction(AppWidgetManager.ActionAppwidgetUpdate);
        //    intent.PutExtra(AppWidgetManager.ExtraAppwidgetIds, appWidgetIds);

        //    // Register click event for the Background
        //    var piBackground = PendingIntent.GetBroadcast(context, 0, intent, PendingIntentFlags.UpdateCurrent);
        //    widgetView.SetOnClickPendingIntent(Resource.Id.widgetBackground, piBackground);
        //}

        //private void SetTextViewText(RemoteViews widgetView)
        //{
        //    widgetView.SetTextViewText(Resource.Id.widgetMedium, "HelloAppWidget");
        //    widgetView.SetTextViewText(Resource.Id.widgetSmall,
        //        string.Format("Last update: {0:H:mm:ss}", DateTime.Now));
        //}
    }
}