<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" encoding="utf-8" />
	<xsl:template match="/">
		<html>
			<head>
				<title>Test</title>
			</head>
			<body>
				<xsl:apply-templates select="body" />
				<br/><b>or</b><br/>
				<xsl:value-of select="//question" />
				<ul>
					<xsl:for-each select="body/type/answer">
						<li>
							<xsl:value-of select="." />
						</li>
					</xsl:for-each>
				</ul>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="body">
		<xsl:apply-templates select="type" />
	</xsl:template>

	<xsl:template match="type">
		<xsl:value-of select="question" />
		<ul>
			<xsl:apply-templates select="answer" />
		</ul>
	</xsl:template>

	<xsl:template match="answer">
		<li>
			<xsl:value-of select="." />
		</li>
	</xsl:template>
</xsl:stylesheet>
