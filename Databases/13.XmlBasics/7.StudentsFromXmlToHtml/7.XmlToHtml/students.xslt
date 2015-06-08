<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes" version='1.0' encoding='UTF-8' />

    <xsl:template match="/">
      <html>
        <body>
          <h2>Students</h2>
          <ul>
            <xsl:for-each select="students/student">
              <li>
                <ul>
                  <li>
                    Full Name:
                    <xsl:value-of select="name"/>
                  </li>
                  <li>
                    Sex: 
                    <xsl:value-of select="sex"/>
                  </li>
                  <li>
                    Birth date:
                    <xsl:value-of select="birthDate"/>
                  </li>
                  <li>
                    Phone:
                    <xsl:value-of select="phone"/>
                  </li>
                  <li>
                    Email:
                    <xsl:value-of select="email"/>
                  </li>
                  <li>
                    Course:
                    <xsl:value-of select="course"/>
                  </li>
                  <li>
                    Speciality:
                    <xsl:value-of select="specialty"/>
                  </li>
                  <li>
                    FN:
                    <xsl:value-of select="facultyNumber"/>
                  </li>
                  <li>
                    TakenExams
                    <xsl:for-each select="takenExams/exam">
                      <ul>
                        <li>
                          Course: 
                          <xsl:value-of select="name"/>
                        </li>
                        <li>
                          Tutor:
                          <xsl:value-of select="tutor"/>
                        </li>
                        <li>
                          Score:
                          <xsl:value-of select="score"/>
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
