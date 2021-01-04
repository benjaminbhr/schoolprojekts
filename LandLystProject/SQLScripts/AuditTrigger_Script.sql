USE [Landlyst]
GO

/****** Object:  Trigger [dbo].[Reservation_Audit_Trg]    Script Date: 13/12/2020 22.54.12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[Reservation_Audit_Trg] on [dbo].[Booking] for insert, update, delete

    as
    set nocount on

BEGIN

    declare @username varchar (50);
    declare @audit_action varchar(100);
    declare @audit_timestamp datetime;

    select @username = system_user;
    select @audit_timestamp = getdate();

    if exists (select * from inserted) and exists (select * from deleted)
        select @audit_action = 'updated'
    else if exists (select * from inserted)
        select @audit_action ='inserted'
    else
        select @audit_action = 'deleted'


    insert dbo.Booking_Audit(Customer_ID,Booking_ID,Room_No,CheckIn_Date,CheckOut_Date,Reservation_Date,Username,audit_action,audit_timestamp)
    select Customer_ID,Booking_ID,Room_No,CheckIn_Date,CheckOut_Date,Reservation_Date, @username, @audit_action + '_old', @audit_timestamp
    from deleted

    insert dbo.Booking_Audit(Customer_ID,Booking_ID,Room_No,CheckIn_Date,CheckOut_Date,Reservation_Date,Username,audit_action,audit_timestamp)
    select Customer_ID,Booking_ID,Room_No,CheckIn_Date,CheckOut_Date,Reservation_Date, @username, @audit_action + '_new', @audit_timestamp
    from inserted

end;
GO

ALTER TABLE [dbo].[Booking] ENABLE TRIGGER [Reservation_Audit_Trg]
GO

