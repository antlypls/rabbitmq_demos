require 'rubygems'
require 'carrot'
require '../settings.rb'

carrot = Carrot.new(:host => HOST)
q = carrot.queue('string_data')
puts "count: #{q.message_count}"

while msg = q.pop
 puts msg
end

carrot.stop
