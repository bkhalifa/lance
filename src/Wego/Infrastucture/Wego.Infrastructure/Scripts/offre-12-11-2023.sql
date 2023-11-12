
/****** Object:  StoredProcedure [dbo].[OfferSearchEngine]    Script Date: 12/11/2023 02:12:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bessem Zbidi
-- Create date: 01/09/2022
-- Description:	Search Job offers 
-- =============================================
ALTER   PROCEDURE [dbo].[OfferSearchEngine]
	@SearchText VARCHAR(250)= null,  -- Gloabl filter	
	@LocationCodes VARCHAR(250)= null,
	@ContractTypeCodes VARCHAR(250) = null,
	@SkillCodes VARCHAR(500) = null,
	@SeniorityCodes VARCHAR(500) = null,
	@CategoryCodes VARCHAR(500) = null,
	@WorkTypeCodes VARCHAR(250) = null,
	@DailyRateMin DECIMAL(18,0)= null,
	@SalaryMin DECIMAL(18,0)= null,
	@PageIndex INT = 1,
	@PageSize INT= 10,
	@OrderBy  INT = 1

AS
BEGIN
    SET NOCOUNT ON;
	
	;WITH CTE_Results
		AS (
			SELECT ROW_NUMBER() OVER (ORDER BY
				CASE WHEN @OrderBy = 1 THEN PublicationDate END DESC, --Date desc
				CASE WHEN @OrderBy = 2 THEN PublicationDate END ASC, --Date asc
				CASE WHEN @OrderBy = 3 THEN ID END DESC) AS RowNumber,  --Date Relevant
			    Id,
				CustomerName,
				Title,
				Description,
				LocationName,
				AmountMin,
				AmountMax,
				AmountUnit,
				WorkTypeCode,
				SkillNames,
				ContractTypeCode,
				SeniorityCode,
				PublicationDate,
				Duration,
				CreatedDate

			FROM dbo.OffersSearch os OUTER APPLY string_split(@SkillCodes,'|') skill
									 OUTER APPLY string_split(@LocationCodes,'|') loc
			WHERE		   
			(@SearchText IS NULL OR Title LIKE '%' + @SearchText + '%')	
			AND (@LocationCodes IS NULL OR os.LocationCode like '%|'+loc.value+'|%') 
			AND (@ContractTypeCodes IS NULL OR @ContractTypeCodes  like '%|'+ContractTypeCode+'|%') 			
			AND (@WorkTypeCodes IS NULL OR @WorkTypeCodes  like '%|'+WorkTypeCode+'|%') 
			AND (@SeniorityCodes IS NULL OR @SeniorityCodes  like '%|'+SeniorityCode+'|%') 
			AND (@CategoryCodes IS NULL OR @CategoryCodes  like '%|'+CategoryCode+'|%')
			AND (@SkillCodes IS NULL OR os.LocationCode like '%|'+skill.value+'|%') 
		    AND (
				    (@DailyRateMin IS NULL AND @SalaryMin IS NULL) 
				 OR (os.ContractTypeCode ='freelance' AND @DailyRateMin <=os.AmountMax)
				 OR (os.ContractTypeCode ='cdi' AND @SalaryMin <= os.AmountMax)
				 )				
		)
		,CTE_RowCounts AS
	    (
			SELECT COUNT(*) as [RowCount] FROM CTE_Results
		)
		
		SELECT *			
		FROM CTE_Results, CTE_RowCounts
		ORDER BY RowNumber ASC OFFSET (@PageIndex-1)*@PageSize ROWS FETCH NEXT @PageSize ROWS ONLY
END

