# Lab Reflection

Building this production-grade API really tied together validation, custom exceptions, and global error handling into a seamless workflow.

Input Validation:* Using data annotations allows us to catch bad inputs right at the door and kick back a clear 400 Bad Request before any messy logic runs.
Domain Exceptions:* When things go wrong deeper in the code—like missing items or duplicate entries—throwing clean domain exceptions keeps our business logic readable and secure without leaking raw stack traces to the client.
Global Exception Handling:* Wrapping it all together with a global exception handler ensures that every unexpected glitch or known exception gets translated uniformly into standard ProblemDetails responses with the correct HTTP status codes