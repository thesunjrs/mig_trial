import pika

# 1. Connect to RabbitMQ
connection = pika.BlockingConnection(
    pika.ConnectionParameters(host='localhost')
)

# 2. Open a channel
channel = connection.channel()

# 3. Send a message
channel.basic_publish(
    exchange='',               # default exchange
    routing_key='demo-pc',  # queue name
    body='Hello from Producer'
)

print("✅ Message sent")

# 4. Close connection
connection.close()