select  count(*) from crm_Accounts
select *from crm_AccountExtraData
select *from crm_TradeAccounts


select *from crm_Leads le where le.AccountId is not NULL


select *from crm_AccountsView acv where acv.IpAddress is not null and acv.IpCountry is not null

select *from crm_Leads
select  *from crm_Accounts


select *from TradingPlatfom.Crm.TABLES

select ac.ItemId,ac.FirstName, ac.LastName from crm_Accounts ac where ac.ItemId='ACC1201170'


select count(*) from crm_Accounts

select ac.ItemId,ac.FirstName, ac.LastName from crm_Accounts ac where ac.Referrer like '%ht%'



select  *from crm_Accounts ac where ac.ConvertionOwnerId is null and ac.RetentionOwnerId is null order by ac.CreatedDate desc						
select  *from crm_AccountsView acf order by acf.CreatedDate desc			
 

select count(*) from crm_LeadsAndAccounts

ac.IsEnabled !=0

SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='TradingPlatfom.Crm'

SELECT name, count(*)
FROM sys.Tables


SELECT 
    t.NAME AS TableName,
    i.name as indexName,
    p.[Rows],
    sum(a.total_pages) as TotalPages, 
    sum(a.used_pages) as UsedPages, 
    sum(a.data_pages) as DataPages,
    (sum(a.total_pages) * 8) / 1024 as TotalSpaceMB, 
    (sum(a.used_pages) * 8) / 1024 as UsedSpaceMB, 
    (sum(a.data_pages) * 8) / 1024 as DataSpaceMB
FROM 
    sys.tables t
INNER JOIN      
    sys.indexes i ON t.OBJECT_ID = i.object_id
INNER JOIN 
    sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
INNER JOIN 
    sys.allocation_units a ON p.partition_id = a.container_id
WHERE 
    t.NAME NOT LIKE 'dt%' AND
    i.OBJECT_ID > 255 AND   
    i.index_id <= 1
GROUP BY 
    t.NAME, i.object_id, i.index_id, i.name, p.[Rows]
ORDER BY 
    object_name(i.object_id) 



	SELECT * FROM sys.tables
	select * from sys.views

	select *from crm_PermissionActions
		select *from crm_Permission
	SELECT *from crm_LeadsAndAccounts where ItemId like 'ACC%'

	select *from crm_Users
	select *from crm_Filters
	
	
	
	
	
	//сумма до двум таблицам
	select 
 ( select count(*) from crm_Leads )
+ 
 ( select count(*) from crm_Accounts ) 
as 
   total_rows
