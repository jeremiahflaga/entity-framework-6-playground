
insert into Person (Id)
values ('00000000-0000-0000-0000-000000000000')
go

insert into PersonDetailOneToMany (Id, PersonId)
values ('00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000')
go

alter table Person
add PersonDetailId uniqueidentifier null 

go

update Person 
   SET PersonDetailId = (select PersonDetailOneToMany.Id 
                            from PersonDetailOneToMany 
                            where PersonDetailOneToMany.PersonId = Person.Id)
go

alter table Person
alter column PersonDetailId uniqueidentifier not null

go

alter table Person
ADD CONSTRAINT [FK_Person_PersonDetailId]  foreign key (PersonDetailId) references PersonDetailOneToMany(Id);

go

