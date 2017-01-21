unit Test;

interface

  procedure TestPascalProcedure;

implementation

procedure TestPascalProcedure;
  var
    a,
    b,
    c:string;
begin
  a:='aaaa';
  b:='bbbb';
  c:=a+#34+b+#34;
  c:=c+' '+a+chr(34)+b+chr(34);
  c:=a+#39+b+#39;
  c:=c+' '+a+chr(39)+b+chr(39);
  a:=c;
end;

begin
end.