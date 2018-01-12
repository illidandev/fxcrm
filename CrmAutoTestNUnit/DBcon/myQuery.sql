select 
 ( select count(*) from crm_Leads )
+ 
 ( select count(*) from crm_Accounts ) 
as 
   total_rows
