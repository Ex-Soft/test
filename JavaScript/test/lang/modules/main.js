if (window.console && console.log)
	console.log("main.js (before)");

import { SmthConst} from "./module1.js";

window.SmthConst = SmthConst;

if (window.console && console.log)
	console.log("main.js (after)");