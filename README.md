# EFCore2GroupJoinIssue
Project to show an error that can occur with EF Core 2.0 and group joins

## How to replicate

If the console is run with a `-d` argument it will ensure that there is a parent recored with no children and you will see the error.  If you run it without any arguments all parents will have children and it will behave as expected.

Logged as issue [9892](https://github.com/aspnet/EntityFrameworkCore/issues/9892)
