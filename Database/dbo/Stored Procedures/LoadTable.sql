CREATE PROCEDURE [dbo].[LoadTable]
	@data CustomType READONLY
AS
	Insert into DataTable(S1, S2, Dt1, Dt2, N1, N2)
	Select S1, S2, Dt1, Dt2, N1, N2
	from @data
RETURN 0
