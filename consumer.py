import pika

# 1. Connect to RabbitMQ
connection = pika.BlockingConnection(
    pika.ConnectionParameters(host='localhost')
)

# 2. Open a channel
channel = connection.channel()

# 3. Function that runs when message arrives
def callback(ch, method, properties, body):
    print("✅ Received:", body.decode())

# 4. Tell RabbitMQ to give messages from queue
channel.basic_consume(
    queue='demo-pc',
    on_message_callback=callback,
    auto_ack=True
)

print("⏳ Waiting for messages...")
channel.start_consuming()