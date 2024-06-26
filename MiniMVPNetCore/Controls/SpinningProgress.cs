using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace MiniMVPNetCore.Controls
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class SpinningProgress : System.Windows.Forms.UserControl
	{
		private Color m_InactiveColour = Color.FromArgb( 218, 218, 218 ); 
		private Color m_ActiveColour = Color.FromArgb( 35, 146, 33 ); 
		private Color m_TransistionColour = Color.FromArgb( 129, 242, 121 ); 
        
		private Region innerBackgroundRegion; 
		private System.Drawing.Drawing2D.GraphicsPath[] segmentPaths = new System.Drawing.Drawing2D.GraphicsPath[ 12 ]; 
        
		private bool m_AutoIncrement = true; 
		private double m_IncrementFrequency = 100; 
		private bool m_BehindIsActive = true; 
		private int m_TransitionSegment = 0; 

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SpinningProgress()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			//  Add any initialization after the InitializeComponent() call.
			CalculateSegments(); 
        
			m_AutoRotateTimer = new System.Timers.Timer( m_IncrementFrequency );
			m_AutoRotateTimer.Stop();

			m_AutoRotateTimer.Elapsed += new System.Timers.ElapsedEventHandler( IncrementTransisionSegment );
		
			this.EnabledChanged += new EventHandler( SpinningProgress_EnabledChanged ); 
			// events handled by ProgressDisk_Paint
			this.Paint += new PaintEventHandler(ProgressDisk_Paint); 
			// events handled by ProgressDisk_Resize
			this.Resize += new EventHandler( ProgressDisk_Resize); 
			// events handled by ProgressDisk_SizeChanged
			this.SizeChanged += new EventHandler(ProgressDisk_SizeChanged); 

			this.SetStyle(
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.DoubleBuffer, true);

			//if(!DesignMode)
			//{
			//    m_AutoRotateTimer.Start(); 
			//}
            //eps colors
            this.ActiveSegmentColour = Color.Green;
            this.TransistionSegmentColour = Color.LimeGreen;
            this.InactiveSegmentColour = SystemColors.Control;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();

				if(m_AutoRotateTimer != null && m_AutoRotateTimer.Enabled)
					m_AutoRotateTimer.Stop();

				if(m_AutoRotateTimer != null)
					m_AutoRotateTimer.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.SuspendLayout(); 
			this.Name = "SpinningProgress"; 
			this.Size = new System.Drawing.Size( 30, 30 ); 
			this.ResumeLayout( false ); 
		}
		#endregion

		private System.Timers.Timer m_AutoRotateTimer;
		[System.ComponentModel.DefaultValue(typeof(Color), "218, 218, 218")]
		public Color InactiveSegmentColour 
		{ 
			get 
			{ 
				return m_InactiveColour; 
			} 
			set 
			{ 
				m_InactiveColour = value; 
				Invalidate(); 
			} 
		}
		[System.ComponentModel.DefaultValue(typeof(Color), "35, 146, 33")]
		public Color ActiveSegmentColour 
		{ 
			get 
			{ 
				return m_ActiveColour; 
			} 
			set 
			{ 
				m_ActiveColour = value; 
				Invalidate(); 
			} 
		} 
		[ System.ComponentModel.DefaultValue( typeof( Color ), "129, 242, 121" ) ]
		public Color TransistionSegmentColour 
		{ 
			get 
			{ 
				return m_TransistionColour; 
			} 
			set 
			{ 
				m_TransistionColour = value; 
				Invalidate(); 
			} 
		}
		[System.ComponentModel.DefaultValue(true)]
		public bool BehindTransistionSegmentIsActive 
		{ 
			get 
			{ 
				return m_BehindIsActive; 
			} 
			set 
			{ 
				m_BehindIsActive = value; 
				Invalidate(); 
			} 
		}
		[System.ComponentModel.DefaultValue(-1)]
		public int TransistionSegment 
		{ 
			get 
			{ 
				return m_TransitionSegment; 
			} 
			set 
			{ 
				if ( value > 11 || value < -1 ) 
				{ 
					throw new ArgumentException( "TransistionSegment must be between -1 and 11" ); 
				} 
				m_TransitionSegment = value; 
				Invalidate(); 
			} 
		}
		[System.ComponentModel.DefaultValue(true)]
		public bool AutoIncrement 
		{ 
			get 
			{ 
				return m_AutoIncrement; 
			} 
			set 
			{ 
				m_AutoIncrement = value; 
                
				if ( value == false && m_AutoRotateTimer != null ) 
				{ 
					m_AutoRotateTimer.Dispose(); 
					m_AutoRotateTimer = null; 
				} 
                
				if ( value == true && m_AutoRotateTimer == null ) 
				{ 
					m_AutoRotateTimer = new System.Timers.Timer( m_IncrementFrequency ); 
					m_AutoRotateTimer.Elapsed += new System.Timers.ElapsedEventHandler( IncrementTransisionSegment ); 
					if(Visible && Enabled)
						m_AutoRotateTimer.Start(); 
				} 
			} 
		}
		[System.ComponentModel.DefaultValue(100)]
		public double AutoIncrementFrequency 
		{ 
			get 
			{ 
				return m_IncrementFrequency; 
			} 
			set 
			{ 
				m_IncrementFrequency = value; 
                
				if ( m_AutoRotateTimer != null ) 
				{ 
					AutoIncrement = false; 
					AutoIncrement = true; 
				} 
			} 
		} 

		private void IncrementTransisionSegment( object sender, System.Timers.ElapsedEventArgs e ) 
		{
			if(Disposing || IsDisposed || !Enabled || !Visible)
			{
				m_AutoRotateTimer.Stop();
				return;
			}
			if ( m_TransitionSegment == 11 ) 
			{ 
				m_TransitionSegment = 0; 
				m_BehindIsActive = !( m_BehindIsActive ); 
			} 
			else if ( m_TransitionSegment == -1 ) 
			{ 
				m_TransitionSegment = 0; 
			} 
			else 
			{ 
				m_TransitionSegment += 1; 
			} 
            
			Invalidate(); 
		}
		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);

			if(Visible)
			{
				if(m_AutoRotateTimer != null)
				{
					m_AutoRotateTimer.Start();
				}
			}
			else
			{
				if(m_AutoRotateTimer != null)
				{
					m_AutoRotateTimer.Stop();
				}
			} 
		}
        
		private void CalculateSegments() 
		{ 
			Rectangle rctFull = new Rectangle( 0, 0, this.Width, this.Height ); 
			Rectangle rctInner = new Rectangle( ((this.Width *  7) / 30),
				((this.Height *  7) / 30),
				(this.Width -  ((this.Width *  14 ) / 30 )),
				(this.Height - ((this.Height * 14) / 30 ))); 

			System.Drawing.Drawing2D.GraphicsPath pthInnerBackground = null; 
            
			// Create 12 segment pieces
			for ( int intCount=0; intCount < 12; intCount++ ) 
			{ 
				segmentPaths[ intCount ] = new System.Drawing.Drawing2D.GraphicsPath(); 
                
				// We subtract 90 so that the starting segment is at 12 o'clock
				segmentPaths[ intCount ].AddPie( rctFull, ( intCount * 30 ) - 90, 25 ); 
			} 
            
			// Create the center circle cut-out
			pthInnerBackground = new System.Drawing.Drawing2D.GraphicsPath(); 
			pthInnerBackground.AddPie( rctInner, 0, 360 ); 
			innerBackgroundRegion = new Region( pthInnerBackground ); 
		} 
        
        
		private void SpinningProgress_EnabledChanged( object sender, System.EventArgs e ) 
		{
            SetTimerEnabled(Enabled);
		}
		delegate void TimerEnabledEventHandler(bool enabled);
		public void SetTimerEnabled(bool enabled)
		{
			if(InvokeRequired)
			{
				if(!IsDisposed && IsHandleCreated)
				{
					Invoke(new TimerEnabledEventHandler(SetTimerEnabled), new object[] { enabled });
				}
				return;
			}
			else
			{
				if(enabled == true)
				{
					if(m_AutoRotateTimer != null)
					{
						m_AutoRotateTimer.Start();
					}
				}
				else
				{
					if(m_AutoRotateTimer != null)
					{
						m_AutoRotateTimer.Stop();
					}
				}
			}
		}
        
        
		private void ProgressDisk_Paint( object sender, System.Windows.Forms.PaintEventArgs e ) 
		{ 
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; 
			e.Graphics.ExcludeClip( innerBackgroundRegion ); 
            
			for ( int intCount=0; intCount < 12; intCount++ ) 
			{ 
				if ( this.Enabled ) 
				{ 
					if ( intCount == m_TransitionSegment ) 
					{ 
						// If this segment is the transistion segment, colour it differently
						e.Graphics.FillPath( new SolidBrush( m_TransistionColour ), segmentPaths[ intCount ] ); 
					} 
					else if ( intCount < m_TransitionSegment ) 
					{ 
						// This segment is behind the transistion segment
						if ( m_BehindIsActive ) 
						{ 
							// If behind the transistion should be active, 
							// colour it with the active colour
							e.Graphics.FillPath( new SolidBrush( m_ActiveColour ), segmentPaths[ intCount ] ); 
						} 
						else 
						{ 
							// If behind the transistion should be in-active, 
							// colour it with the in-active colour
							e.Graphics.FillPath( new SolidBrush( m_InactiveColour ), segmentPaths[ intCount ] ); 
						} 
					} 
					else 
					{ 
						// This segment is ahead of the transistion segment
						if ( m_BehindIsActive ) 
						{ 
							// If behind the the transistion should be active, 
							// colour it with the in-active colour
							e.Graphics.FillPath( new SolidBrush( m_InactiveColour ), segmentPaths[ intCount ] ); 
						} 
						else 
						{ 
							// If behind the the transistion should be in-active, 
							// colour it with the active colour
							e.Graphics.FillPath( new SolidBrush( m_ActiveColour ), segmentPaths[ intCount ] ); 
						} 
					} 
				} 
				else 
				{ 
					// Draw all segments in in-active colour if not enabled
					e.Graphics.FillPath( new SolidBrush( m_InactiveColour ), segmentPaths[ intCount ] ); 
				} 
			} 
		} 
        
        
		private void ProgressDisk_Resize( object sender, System.EventArgs e ) 
		{ 
			CalculateSegments(); 
		} 
        
        
		private void ProgressDisk_SizeChanged( object sender, System.EventArgs e ) 
		{ 
			CalculateSegments(); 
		} 
	}
}
