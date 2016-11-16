set names utf8;

connect "C:\Program Files\Firebird\Firebird_2_5\TESTDB.FDB" user "sysdba" password "masterkey";

set term ^;

create or alter trigger tr_TableWithHierarchy_AIU for TableWithHierarchy
after insert or update
as
  declare m_path varchar(256) character set utf8;
  declare m_old_path varchar(256) character set utf8;
begin
  execute procedure GetTableWithHierarchyMPath(new.Id) returning_values :m_path;

  if (updating) then
    begin
      if (new.ParentId is distinct from old.ParentId) then
        begin
          m_old_path = old.MaterializedPath;

          update
            TableWithHierarchy
          set
            MaterializedPath=:m_path
          where
            id=new.Id;

          update
            TableWithHierarchy
          set
            MaterializedPath=:m_path||substring(MaterializedPath from (char_length(:m_old_path)+1))
          where
            MaterializedPath starting with :m_old_path;
        end
    end
  else
      update
        TableWithHierarchy
      set
        MaterializedPath=:m_path
      where
        id=new.Id;
end
^

set term ;^