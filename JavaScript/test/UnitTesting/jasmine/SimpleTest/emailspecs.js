describe('validateEmail', () => {
	it('returns true when email is correct', () => {
		const emails = [ 'john@email.school', 'john@email-address.com', 'john+doe@email.com', 'john-doe@email.com', 'John123@email.com', 'ben&jerrys@email.com', 'john%doe@Email.com', 'johndoe\'s@email.com' ];

		for (let i = 0, l = emails.length; i < l; ++i) {
			const actual = validateEmail(emails[i]);
			expect(actual).toBeTruthy();
		}
	});

	it('returns false when email is undefined or null or empty string', () => {
		let actual = validateEmail(undefined);
		expect(actual).toBeFalsy();

		actual = validateEmail(null);
		expect(actual).toBeFalsy();

		actual = validateEmail('');
		expect(actual).toBeFalsy();
	});

	it('returns false when email isn\'t matched', () => {
		const emails = [ 'test@', 'test@email.', 'test.com', '.test@email.com', 'test.@email.com', 'te..st@email.com', 'test@.email.com', '😑email@comcast.net', 'first name@comcast.net', 'tést@email.com', '@email.com' ];

		for (let i = 0, l = emails.length; i < l; ++i) {
			const actual = validateEmail(emails[i]);
			expect(actual).toBeFalsy();
		}
	});

	it('returns false when length of email exceeds 254 octets', () => {
		let email = '1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567@123456789012345678901234567890123456789012345678901234567890123.123456789012345678901234567890123456789012345678901234567890123';
		let actual = validateEmail(email);
		expect(email.length).toBe(255);
		expect(actual).toBeFalsy();
		
		email = '1234567890123456789012345678901234567890123456789012345678901234@123456789012345678901234567890123456789012345678901234567890123.123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456';
		actual = validateEmail(email);
		expect(email.length).toBe(255);
		expect(actual).toBeFalsy();
	});

	it('returns true when length of local-part doesn\'t exceed 64 octets', () => {
		const localPart = '1234567890123456789012345678901234567890123456789012345678901234';
		const actual = validateEmail(`${localPart}@1234567890.com`);
		expect(localPart.length).toBe(64);
		expect(actual).toBeTruthy();
	});

	it('returns false when length of local-part exceeds 64 octets', () => {
		const localPart = '12345678901234567890123456789012345678901234567890123456789012345';
		const actual = validateEmail(`${localPart}@1234567890.com`);
		expect(localPart.length).toBe(65);
		expect(actual).toBeFalsy();
	});
	
	it('returns true when length of domain doesn\'t exceed 252 octets', () => {
		const domain = '123456789012345678901234567890123456789012345678901234567890123.45678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901';
		const actual = validateEmail(`1@${domain}`);
		expect(domain.length).toBe(252);
		expect(actual).toBeTruthy();
	});
	
	it('returns false when length of domain exceeds 252 octets', () => {
		const domain = '123456789012345678901234567890123456789012345678901234567890123.456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012';
		const actual = validateEmail(`1@${domain}`);
		expect(domain.length).toBe(253);
		expect(actual).toBeFalsy();
	});

	it('returns true when length of subdomain doesn\'t exceed 63 octets', () => {
		const subdomain = '123456789012345678901234567890123456789012345678901234567890123';
		const actual = validateEmail(`1@${subdomain}.com`);
		expect(subdomain.length).toBe(63);
		expect(actual).toBeTruthy();
	});

	it('returns false when length of subdomain exceeds 63 octets', () => {
		const subdomain = '1234567890123456789012345678901234567890123456789012345678901234';
		const actual = validateEmail(`1@${subdomain}.com`);
		expect(subdomain.length).toBe(64);
		expect(actual).toBeFalsy();
	});
});
