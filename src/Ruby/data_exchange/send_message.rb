require 'rubygems'
require 'carrot'
require '../settings.rb'
require 'message.rb'

carrot = Carrot.new(:host => HOST)
q = carrot.queue('message_data', :durable => true)
(1..10).each {|i|
  message = Message.new
  message.from = 'Ruby sample.'
  message.body = "Message. #{i}."

  q.publish(Marshal.dump(message))
}