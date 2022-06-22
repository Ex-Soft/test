describe("Date", function () {
	it("test addDays()", function () {
		let date = new Date(2020, 1, 28);
        let actual = addDays(date, -1);
        expect(actual.getFullYear()).toBe(2020);
        expect(actual.getMonth()).toBe(1);
        expect(actual.getDate()).toBe(27);
		expect(actual.getHours()).toBe(0);
        expect(actual.getMinutes()).toBe(0);
        expect(actual.getSeconds()).toBe(0);
        expect(actual.getMilliseconds()).toBe(0);
		
		date = new Date(2020, 1, 28);
        actual = addDays(date, 1);
        expect(actual.getFullYear()).toBe(2020);
        expect(actual.getMonth()).toBe(1);
        expect(actual.getDate()).toBe(29);
		expect(actual.getHours()).toBe(0);
        expect(actual.getMinutes()).toBe(0);
        expect(actual.getSeconds()).toBe(0);
        expect(actual.getMilliseconds()).toBe(0);

        date = new Date(2020, 1, 29);
        actual = addDays(date, 1);
        expect(actual.getFullYear()).toBe(2020);
        expect(actual.getMonth()).toBe(2);
        expect(actual.getDate()).toBe(1);
		expect(actual.getHours()).toBe(0);
        expect(actual.getMinutes()).toBe(0);
        expect(actual.getSeconds()).toBe(0);
        expect(actual.getMilliseconds()).toBe(0);
		
		date = new Date(2020, 11, 31);
        actual = addDays(date, 1);
        expect(actual.getFullYear()).toBe(2021);
        expect(actual.getMonth()).toBe(0);
        expect(actual.getDate()).toBe(1);
		expect(actual.getHours()).toBe(0);
        expect(actual.getMinutes()).toBe(0);
        expect(actual.getSeconds()).toBe(0);
        expect(actual.getMilliseconds()).toBe(0);
	});
});
