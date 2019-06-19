# OrderBy(*TParameters*, *TQueryResult*, *TSqlExpression*) Class
 

The `ORDER BY`-statement of a <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;WeelinkIT.FluentSQL.Querying.Statements.OrderBy(TParameters, TQueryResult, TSqlExpression)<br />
**Namespace:**&nbsp;<a href="b0392358-8a14-f4ef-0b6f-e6856848b769">WeelinkIT.FluentSQL.Querying.Statements</a><br />**Assembly:**&nbsp;Weelink-IT.FluentSQL (in Weelink-IT.FluentSQL.dll) Version: 1.0.0

## Syntax

**C#**<br />
``` C#
public class OrderBy<TParameters, TQueryResult, TSqlExpression> : QueryComponent<TParameters, TQueryResult>
where TParameters : new()

```


#### Type Parameters
&nbsp;<dl><dt>TParameters</dt><dd>The parameters required for executing this <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.</dd><dt>TQueryResult</dt><dd>The result type of the <a href="82639357-28f5-d7fe-833e-926791d1bac8">Query(TParameters, TQueryResult)</a>.</dd><dt>TSqlExpression</dt><dd>The expression to order by.</dd></dl>&nbsp;
The OrderBy(TParameters, TQueryResult, TSqlExpression) type exposes the following members.


## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="ad314998-b327-8433-8652-3255fe8a50ab">Ascending</a></td><td>
Apply the ordering ascending.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="d807c7f7-53fa-f376-7949-5a6392bb007e">Descending</a></td><td>
Apply the ordering descending.</td></tr></table>&nbsp;
<a href="#orderby(*tparameters*,-*tqueryresult*,-*tsqlexpression*)-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#orderby(*tparameters*,-*tqueryresult*,-*tsqlexpression*)-class">Back to Top</a>

## See Also


#### Reference
<a href="b0392358-8a14-f4ef-0b6f-e6856848b769">WeelinkIT.FluentSQL.Querying.Statements Namespace</a><br />