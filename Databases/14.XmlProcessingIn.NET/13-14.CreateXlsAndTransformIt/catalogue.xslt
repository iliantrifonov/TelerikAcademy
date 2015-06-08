<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes" version='1.0' encoding='UTF-8' />

  <xsl:template match="/">
    <html>
      <body>
        <h2>Catalogue</h2>
        <ul>
          <xsl:for-each select="catalogue/album">
            <li>
              <ul>
                <li>
                  Year: <xsl:value-of select="@year"/>
                  Album: <xsl:value-of select="@album-name"/>
                  Artist: <xsl:value-of select="@artist"/>
                </li>
                <li>
                  Songs
                  <xsl:for-each select="song">
                    <ul>
                      <li>
                        Title:
                        <xsl:value-of select="title"/>
                      </li>
                      <li>
                        Duration
                        <xsl:value-of select="duration"/>
                      </li>
                    </ul>
                  </xsl:for-each>
                </li>
              </ul>
            </li>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
