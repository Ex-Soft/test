<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="windows-1251" />
<xsl:template match="/">
	<html>
		<head>
			<title>Data III</title>
		</head>
		<body>
			<table border="1">
				<tr>
					<td>TD</td>
					<td>
						<table border="1">
							<xsl:for-each select="Items/item[position() &lt; 11]">
								<xsl:apply-templates select=".">
									<xsl:with-param name="P" select="position()" />
								</xsl:apply-templates>
							</xsl:for-each>
						</table>
					</td>
				</tr>
			</table>
		</body>
	</html>
</xsl:template>

<xsl:template match="item">
	<xsl:param name="P"/>
	<tr>
		<td><xsl:value-of select="num" /></td>
		<td><xsl:value-of select="date" /></td>
		<td><xsl:value-of select="../item[$P + 10]/num" /></td>
		<td><xsl:value-of select="../item[$P + 10]/date" /></td>
	</tr>
</xsl:template>

</xsl:stylesheet>
