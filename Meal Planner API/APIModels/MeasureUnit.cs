using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal_Planner_API.APIModels {
	[Serializable]
	public class MeasureUnit {
		public int MeasureUnitId { get; set; }
		public string Name { get; set; }

		public MeasureUnit() { }
		public MeasureUnit(Data.Models.MeasureUnit measureUnit) {
			this.MeasureUnitId = measureUnit.MeasureUnitId;
			this.Name = measureUnit.Name;
		}
		public Data.Models.MeasureUnit ToRepo() {
			return new Data.Models.MeasureUnit {
				MeasureUnitId = this.MeasureUnitId,
				Name = this.Name
			};
		}
	}
}
