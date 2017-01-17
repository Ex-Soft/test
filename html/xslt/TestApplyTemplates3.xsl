<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" encoding="windows-1251" />
	<xsl:template match="root">
		<html>
			<head>
				<title>Test apply-templates II</title>
			</head>
			<body>
				<table border="1">
					<xsl:apply-templates />
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="item">
		<tr><xsl:apply-templates  /></tr>
	</xsl:template>

	<xsl:template match="value1|value2|value3">
		<td><xsl:apply-templates /></td>
	</xsl:template>
</xsl:stylesheet>
