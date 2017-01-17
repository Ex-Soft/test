<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" encoding="windows-1251" />
	<xsl:template match="root">
		<html>
			<head>
				<title>Test apply-templates I</title>
			</head>
			<body>
				<xsl:apply-templates />
			</body>
		</html>
	</xsl:template>

	<xsl:template match="item">
		<xsl:value-of select="count(*)" /><xsl:value-of select="position()" /><xsl:apply-templates  /><br />
	</xsl:template>

</xsl:stylesheet>
