alter table PersonDetailOneToMany
add UniquePersonId uniqueidentifier null 

go

update PersonDetailOneToMany 
   SET UniquePersonId = PersonId

go

alter table PersonDetailOneToMany
alter column UniquePersonId uniqueidentifier not null

go

alter table PersonDetailOneToMany
ADD CONSTRAINT [UC_PersonDetailOneToMany_UniquePersonId]  UNIQUE (UniquePersonId);

go


alter table PersonDetailOneToMany
ADD CONSTRAINT [FK_PersonDetailOneToMany_UniquePersonId]  foreign key (UniquePersonId) references [Person](Id);

go

