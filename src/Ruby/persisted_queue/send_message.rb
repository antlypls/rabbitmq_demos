require 'rubygems'
require 'carrot'
require '../settings.rb'

carrot = Carrot.new(:host => HOST)
q = carrot.queue('string_data', :durable => true)
(0..4).each {|i|
  q.publish("Hello from Ruby! Message No. #{i*2}")
  q.publish("Hello from Ruby! Message No. #{i*2+1}", :persistent => true)
}
