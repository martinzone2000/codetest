### *Don't worry, this position won't involve writing server rendered html. :)*

# Objective
We built a page to solve basic math equations, but received a customer request to add support for more mathematical operators.
Right now, equations are solved using a switch statement and lambda functions, but this won't scale well as every time we need to add another operator, we need to add another case in the switch statement, and another lambda function.
### Please implement the following features:
* Replace existing lambda calculations by building a BinaryExpression that can be invoked as a `Func<T, TResult>`
* Add tests to confirm the new code performs calculations correctly.
* Submit a Pull Request with your solution. 
