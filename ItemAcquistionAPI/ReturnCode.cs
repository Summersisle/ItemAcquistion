using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAcquistionAPI {
	public enum ReturnCode {
		SUCCESS,
		ERROR,
		ERROR_ITEM_ALREADY_EXISTS,
		ERROR_NO_ITEM_FOUND,
		ERROR_ITEM_ALREADY_HAS_RECIPE
	}
}
