create table TestTableMaxSecondary
(
   id int not null constraint pk_TestTableMaxSecondary primary key,
   parent_id int not null,
   dt date not null,
   value_id int not null,
   constraint fk_TestTableMaxPri_Sec foreign key (parent_id) references TestTableMaxPrimary (id),
   constraint fk_TestTableMaxVal_Sec foreign key (value_id) references TestTableMaxValues (id)
);

create index idx_TestTableMaxSecondary on TestTableMaxSecondary (parent_id, dt);