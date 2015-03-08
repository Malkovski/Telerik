namespace ExercisingOOP
{
	using System;

	public class Battery
	{
		private string batteryModel;
		private int idleHours;
		private int talkHours;
		private BatteryType type;

		public Battery(string batteryModel)
		{
			this.BatteryModel = batteryModel;         
		}

		public Battery(string batteryModel, BatteryType type, int idleHours, int talkHours) : this(batteryModel)
		{
			this.IdleHours = idleHours;
			this.TalkHours = talkHours;
			this.Type = Type;
		}

		public string BatteryModel
		{
			get
			{ 
				return this.batteryModel; 
			}      
			set 
			{
					if (value == null)
					{
						throw new ArgumentException("Data must not be null!");	 
					}

				this.batteryModel = value; 
			}
		}

		public int IdleHours
		{ 
			get
			{ 
				return this.idleHours; 
			}
			set
			{
				int valueType = 0;

				if (int.TryParse(value.ToString(), out valueType) == false)
				{
					throw new ArgumentException("Use only symbols from 0...9!");
				}

				this.idleHours = value; 
			}
		}

		public int TalkHours
		{
			get
			{ 
				return this.talkHours;
			}
			set
			{
				int valueType = 0;

				if (int.TryParse(value.ToString(), out valueType) == false)
				{
					throw new ArgumentException("Use only symbols from 0...9!");
				}

				this.talkHours = value; 
			}
		}

		public BatteryType Type
		{
			get;
			set;
		}
	}
}
