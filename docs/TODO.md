# TODO 

- Add functionality for notifying other services about session tokens: 
    - Parameters that could be specified in config file:
        - HTTP, TCP, AMQP (RabbitMQ);
        - IP addresses.
- Add functionality for interacting with DB:
    - Parameters that could be specified in config file:
        - Type: SQLite, PostgreSQL, MySQL, MS SQL.
        - SQL, EntityFramework.
        - Connection string.
- When a user gets session token, there's a potential threat that an attacker could generate user UID and get session their token.
