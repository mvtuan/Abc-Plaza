package md5f63358126ff04cb2936ce5c14c5449f1;


public class ApartmentViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Staff.C_Sharp.ApartmentViewHolder, Staff", ApartmentViewHolder.class, __md_methods);
	}


	public ApartmentViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ApartmentViewHolder.class)
			mono.android.TypeManager.Activate ("Staff.C_Sharp.ApartmentViewHolder, Staff", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
