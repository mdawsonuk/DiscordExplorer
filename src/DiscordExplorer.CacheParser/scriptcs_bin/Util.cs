using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DiscordExplorer.CacheParser
{
    internal class Util
    {
        internal static T ByteToType<T>(BinaryReader reader)
        {
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();

            return theStructure;
        }
	
		internal static DateTime ConvertWebkitTime(ulong timestamp)
		{
			TimeSpan time = TimeSpan.FromMilliseconds((double)(timestamp/1000));
			DateTime date = new DateTime(1601, 1, 1) + time;
			return date;
		}

		internal static object CreateDynamicList(Type type, params object[] args)
		{
			Type specificType = typeof(List<>).MakeGenericType(new Type[] { type } );
			return Activator.CreateInstance(specificType, args);
		}
    }
}
