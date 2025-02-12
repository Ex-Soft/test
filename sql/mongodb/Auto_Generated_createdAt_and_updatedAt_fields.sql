// https://mongoosejs.com/docs/timestamps.html

const mongoose = require("mongoose');

const userSchema = new mongoose.Schema({
	name: { type: String },
	age: { type: Number }
});

userSchema.set("timestamps", true);
// ||
userSchema.set("timestamps", {
	createdAt: "crdAt",
	updatedAt: "updAt"
});

// ||

const userSchema = new mongoose.Schema({
	name: { type: String },
	age: { type: Number },
}, {
	timestamps:  {
		createdAt: "crdAt",
		updatedAt: "updAt"
	}
});

module.exports = mongoose.model("user", userSchema, "demo");
