<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" encoding="windows-1251" />
	<xsl:template match="root">
		<html>
			<head>
				<title>Test Right Column</title>
			</head>
			<body>
				<table border="1">
					<tr>
						<td>Value 2</td>
						<td>
							<xsl:for-each select="value">
								<xsl:if test="@id=2">
									<xsl:value-of select="." />
								</xsl:if>
							</xsl:for-each>
						</td>
					</tr>
					<tr>
						<td>Value 3</td>
						<td>
							<xsl:for-each select="value">
								<xsl:if test="@id=3">
									<xsl:value-of select="." />
								</xsl:if>
							</xsl:for-each>
						</td>
					</tr>
					<tr>
						<td>Value 1</td>
						<td>
							<xsl:for-each select="value">
								<xsl:if test="@id=1">
									<xsl:value-of select="." />
								</xsl:if>
							</xsl:for-each>
						</td>
					</tr>
				</table>
				<hr />
				<table border="1">
					<tr>
						<td>Value 2</td>
						<td>
							<xsl:for-each select="value[@id=2]">
								<xsl:value-of select="." />
							</xsl:for-each>
						</td>
					</tr>
					<tr>
						<td>Value 3</td>
						<td>
							<xsl:for-each select="value[@id=3]">
								<xsl:value-of select="." />
							</xsl:for-each>
						</td>
					</tr>
					<tr>
						<td>Value 1</td>
						<td>
							<xsl:for-each select="value[@id=1]">
								<xsl:value-of select="." />
							</xsl:for-each>
						</td>
					</tr>
				</table>
				<hr />
				<table border="1">
					<tr>
						<td>Value 2</td>
						<td>
							<xsl:for-each select="value">
								<xsl:choose>
									<xsl:when test="@id=2">
										<xsl:value-of select="." />
									</xsl:when>
								</xsl:choose>
							</xsl:for-each>
						</td>
					</tr>
					<tr>
						<td>Value 3</td>
						<td>
							<xsl:for-each select="value">
								<xsl:choose>
									<xsl:when test="@id=3">
										<xsl:value-of select="." />
									</xsl:when>
								</xsl:choose>
							</xsl:for-each>
						</td>
					</tr>
					<tr>
						<td>Value 1</td>
						<td>
							<xsl:for-each select="value">
								<xsl:choose>
									<xsl:when test="@id=1">
										<xsl:value-of select="." />
									</xsl:when>
								</xsl:choose>
							</xsl:for-each>
						</td>
					</tr>
				</table>
				<hr />
				<table border="1">
					<xsl:for-each select="value">
						<tr>
							<td>
								<xsl:choose>
									<xsl:when test="@id=1">
										Value 1
									</xsl:when>
									<xsl:when test="@id=2">
										Value 2
									</xsl:when>
									<xsl:when test="@id=3">
										Value 3
									</xsl:when>
								</xsl:choose>

							</td>
							<td>
								<xsl:value-of select="." />
							</td>
						</tr>
					</xsl:for-each>
				</table>
				<hr />
				<xsl:variable name="CountCount" select="count(value[@id=3])" />
				<xsl:if test="$CountCount=1">Yes!!!</xsl:if>
				<xsl:if test="count(value[@id=2])=1">Yes!!!</xsl:if>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
