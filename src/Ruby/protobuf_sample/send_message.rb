require 'rubygems'
require 'carrot'
require '../settings.rb'
require 'message.pb.rb'

carrot = Carrot.new(:host => HOST)

q = carrot.queue('message_data', :durable => true)
(1..10).each {|i|
  message = Message.new :id => i, :from => 'Ruby sample.', :body => "Message. #{i}."
  q.publish(message.to_s)
}