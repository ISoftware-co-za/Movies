
using Android.App;
using Android.OS;
using Android.Views;

namespace Movies.View.Android
{
    public class FragmentMovieDetails : Fragment
    {
        public override global::Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            return inflater.Inflate(Resource.Layout.FragmentMovieDetails, container, false);
        }
    }
}