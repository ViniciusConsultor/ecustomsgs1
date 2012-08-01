using System;
using System.IO;

namespace ApplicationUtils.Utils.ZipUtils.Core
{
	/// <summary>
	/// Provides simple <see cref="Stream"/>" utilities.
	/// </summary>
	public sealed class StreamUtils
	{
		/// <summary>
		/// Read from a <see cref="Stream"/> ensuring all the required data is read.
		/// </summary>
		/// <param name="stream">The stream to read.</param>
		/// <param name="buffer">The buffer to fill.</param>
		public static void ReadFully(Stream stream, byte[] buffer)
		{
			ReadFully(stream, buffer, 0, buffer.Length);
		}

		/// <summary>
		/// Read from a <see cref="Stream"/>" ensuring all the required data is read.
		/// </summary>
		/// <param name="stream">The stream to read data from.</param>
		/// <param name="buffer">The buffer to store data in.</param>
		/// <param name="offset">The offset at which to begin storing data.</param>
		/// <param name="count">The number of bytes of data to store.</param>
		public static void ReadFully(Stream stream, byte[] buffer, int offset, int count)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}

			// Offset can equal length when buffer and count are 0.
			if ((offset < 0) || (offset > buffer.Length))
			{
				throw new ArgumentOutOfRangeException("offset");
			}

			if ((count < 0) || (offset + count > buffer.Length))
			{
				throw new ArgumentOutOfRangeException("count");
			}

			while (count > 0)
			{
				int readCount = stream.Read(buffer, offset, count);
				if (readCount <= 0)
				{
					throw new EndOfStreamException();
				}
				offset += readCount;
				count -= readCount;
			}
		}

		/// <summary>
		/// Copy the contents of one <see cref="Stream"/> to another.
		/// </summary>
		/// <param name="source">The stream to source data from.</param>
		/// <param name="destination">The stream to write data to.</param>
		/// <param name="buffer">The buffer to use during copying.</param>
		/// <param name="progressHandler">The <see cref="ProgressHandler">progress handler delegate</see> to use.</param>
		/// <param name="updateInterval">The minimum <see cref="TimeSpan"/> between progress updates.</param>
		/// <param name="sender">The source for this event.</param>
		/// <param name="name">The name to use with the event.</param>
		public static void Copy(Stream source, Stream destination,
		                        byte[] buffer, ProgressHandler progressHandler, TimeSpan updateInterval, object sender, string name)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}

			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}

			// Ensure a reasonable size of buffer is used without being prohibitive.
			if (buffer.Length < 128)
			{
				throw new ArgumentException("Buffer is too small", "buffer");
			}

			if (progressHandler == null)
			{
				throw new ArgumentNullException("progressHandler");
			}

			bool copying = true;

			DateTime marker = DateTime.Now;
			long processed = 0;
			long target = 0;

			if (source.CanSeek)
			{
				target = source.Length - source.Position;
			}

			// Always fire 0% progress..
			ProgressEventArgs args = new ProgressEventArgs(name, processed, target);
			progressHandler(sender, args);

			bool completeFired = false;

			while (copying)
			{
				int bytesRead = source.Read(buffer, 0, buffer.Length);
				if (bytesRead > 0)
				{
					processed += bytesRead;
					destination.Write(buffer, 0, bytesRead);
				}
				else
				{
					destination.Flush();
					copying = false;
				}

				if (DateTime.Now - marker > updateInterval)
				{
					completeFired = (processed == target);
					marker = DateTime.Now;
					args = new ProgressEventArgs(name, processed, target);
					progressHandler(sender, args);

					copying = args.ContinueRunning;
				}
			}

			if (!completeFired)
			{
				args = new ProgressEventArgs(name, processed, target);
				progressHandler(sender, args);
			}
		}

		/// <summary>
		/// Copy the contents of one <see cref="Stream"/> to another.
		/// </summary>
		/// <param name="source">The stream to source data from.</param>
		/// <param name="destination">The stream to write data to.</param>
		/// <param name="buffer">The buffer to use during copying.</param>
		public static void Copy(Stream source, Stream destination, byte[] buffer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}

			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}

			// Ensure a reasonable size of buffer is used without being prohibitive.
			if (buffer.Length < 128)
			{
				throw new ArgumentException("Buffer is too small", "buffer");
			}

			bool copying = true;

			while (copying)
			{
				int bytesRead = source.Read(buffer, 0, buffer.Length);
				if (bytesRead > 0)
				{
					destination.Write(buffer, 0, bytesRead);
				}
				else
				{
					destination.Flush();
					copying = false;
				}
			}
		}

		/// <summary>
		/// Initialise an instance of <see cref="StreamUtils"></see>
		/// </summary>
		private StreamUtils()
		{
			// Do nothing.
		}
	}
}