<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" encoding="windows-1251" />
	<xsl:template match="root/item">
		<html>
			<head>
				<title>Test Variable II</title>
			</head>
			<body>
				<xsl:variable name="colorDef" select="'red'"/>
				<div id="{string(@name)}">
					<xsl:attribute name="color">
						<xsl:choose>
							<xsl:when test="@color">
								<xsl:value-of select="@color"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="$colorDef"/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:attribute>
					Test
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
