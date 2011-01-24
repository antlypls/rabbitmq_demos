class Message
  attr_accessor :from, :body
  def print
    puts "From: #{@from}\nBody: #{@body}"
  end
end
