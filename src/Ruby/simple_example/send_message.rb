require 'rubygems'
require 'carrot'
require '../settings.rb'

carrot = Carrot.new(:host => HOST)
q = carrot .queue('string_data')
(1..10).each {|i|
  q.publish("Hello from Ruby! Message No. #{i}")
}
