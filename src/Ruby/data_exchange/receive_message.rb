require 'rubygems'
require 'carrot'
require '../settings.rb'
require 'message.rb'

carrot = Carrot.new(:host => HOST)
q = carrot.queue('message_data', :durable => true)

puts "count: #{q.message_count}"
while data = q.pop(:ack => true)
  message = Marshal.load(data)
  message.print
  q.ack
end

carrot.stop