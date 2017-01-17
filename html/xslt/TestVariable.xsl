<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" encoding="windows-1251" />
	<xsl:template match="root">
		<html>
			<head>
				<title>Test Variable</title>
			</head>
			<body>
				<xsl:variable name="CountCount" select="count(item/value3)" />
				<xsl:if test="$CountCount=3">3</xsl:if>
				<xsl:value-of select="$CountCount" />
				<xsl:value-of select="count(item/value1)" />
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
