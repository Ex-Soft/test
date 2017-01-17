<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" encoding="windows-1251" />
	<xsl:template match="root">
		<html>
			<head>
				<title>Test Attribute</title>
			</head>
			<body>
				<xsl:apply-templates />
			</body>
		</html>
	</xsl:template>

	<xsl:attribute-set name="attribute-value1">
		<xsl:attribute name="size">-1</xsl:attribute>
		<xsl:attribute name="color">red</xsl:attribute>
		<xsl:attribute name="face">Tahoma</xsl:attribute>
	</xsl:attribute-set>

	<xsl:attribute-set name="attribute-value2">
		<xsl:attribute name="size">+1</xsl:attribute>
		<xsl:attribute name="color">blue</xsl:attribute>
		<xsl:attribute name="face">Verdana</xsl:attribute>
	</xsl:attribute-set>

	<xsl:template match="item">
		<xsl:apply-templates  /><br />
	</xsl:template>

	<xsl:template match="value1">
		<font xsl:use-attribute-sets="attribute-value1">
			<xsl:apply-templates  />
		</font>
	</xsl:template>

	<xsl:template match="value2">
		<font xsl:use-attribute-sets="attribute-value2">
			<xsl:apply-templates  />
		</font>
	</xsl:template>

</xsl:stylesheet>
