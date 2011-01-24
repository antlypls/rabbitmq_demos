require 'rubygems'
require 'carrot'
require '../settings.rb'
require 'message.pb.rb'

carrot = Carrot.new(:host => HOST)

q = carrot.queue('message_data', :durable => true)

puts "count: #{q.message_count}"
while data = q.pop(:ack => true)
  message = Message.new
  message.parse_from_string(data)
  p message
  q.ack
end

carrot.stop