function validateEmail(email) {
	const EMAIL_REGEXP = /^(?<localPart>[a-zA-Z0-9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+\/=?^_`{|}~-]+)*)@(?<domain>(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)(?:\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)+))$/;
	let match;
	
	if (!!email) {
		match = email.match(EMAIL_REGEXP);
		console.log("match=%o", match);
		if (match) {
			console.log("all=%i", match[0].length);
			console.log("localPart=%i", match.groups.localPart.length);
			console.log("domain=%i", match.groups.domain.length);
			match.groups.domain.split('.').forEach(subDomain => console.log("subDomain=%i", subDomain.length));
		}
	}
	
	return !!email
			&& (match = email.match(EMAIL_REGEXP))
			&& match.length === 3
			&& match[0].length < 255
			&& match.groups.localPart.length < 65
			&& match.groups.domain.length < 253
			&& match.groups.domain.split('.').every((subDomail, index, array) => index === array.length - 1 || subDomail.length < 64)
}
