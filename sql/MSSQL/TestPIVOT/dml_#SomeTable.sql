-- http://wiki.lessthandot.com/index.php/Row_To_Column_%28PIVOT%29

CREATE TABLE #SomeTable
(SomeName VARCHAR(49), Quantity INT)

INSERT INTO #SomeTable VALUES ('Scarface', 2)
INSERT INTO #SomeTable VALUES ('Scarface', 4)
INSERT INTO #SomeTable VALUES ('LOTR', 5)
INSERT INTO #SomeTable VALUES ('LOTR', 6)
INSERT INTO #SomeTable VALUES ( 'Jaws', 2)
INSERT INTO #SomeTable VALUES ('Blade', 5)
INSERT INTO #SomeTable VALUES ('Saw', 6)
INSERT INTO #SomeTable VALUES ( 'Saw', 2)
INSERT INTO #SomeTable VALUES ( 'Jaws', 12)
INSERT INTO #SomeTable VALUES ('Blade', 5)
INSERT INTO #SomeTable VALUES ('Saw', 6)
INSERT INTO #SomeTable VALUES ( 'Saw', 2)

SELECT
  SUM(CASE SomeName WHEN 'Scarface' THEN Quantity ELSE 0 END) AS Scarface,
  SUM(CASE SomeName WHEN 'LOTR' THEN Quantity ELSE 0 END) AS LOTR,
  SUM(CASE SomeName WHEN 'Jaws' THEN Quantity ELSE 0 END) AS Jaws,
  SUM(CASE SomeName WHEN 'Saw' THEN Quantity ELSE 0 END) AS Saw,
  SUM(CASE SomeName WHEN 'Blade' THEN Quantity ELSE 0 END) AS Blade
FROM
  #SomeTable

SELECT
  Scarface, LOTR, Jaws, Saw,Blade
FROM
(
   SELECT
     SomeName, Quantity
   FROM
     #SomeTable
) AS pivTemp
PIVOT
(
   SUM(Quantity)
   FOR SomeName IN (Scarface, LOTR, Jaws, Saw, Blade)
) AS pivTable

drop table #SomeTable
